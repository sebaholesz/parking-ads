import { HttpService } from '@nestjs/axios';
import { CACHE_MANAGER, Inject, Injectable } from '@nestjs/common';
import { Cron } from '@nestjs/schedule';
import { Cache } from 'cache-manager';
import { AppError } from './appError';

@Injectable()
export class AppService {
  constructor(
    private readonly httpService: HttpService,
    @Inject(CACHE_MANAGER) private cacheManager: Cache,
  ) {}

  @Cron('*/10 * * * * *')
  async handleCron(): Promise<void> {
    try {
      const adResponse = await this.httpService.axiosRef.get<string>(
        process.env.BRIANS_AD_SERVICE_URL,
      );

      if (
        adResponse.status === 200 &&
        !adResponse.data.includes('Something bad happened')
      ) {
        this.storeAdInCache(adResponse.data);
      }
    } catch (error) {
      console.log('Could not fetch and store an ad.', error);
    }
  }

  async getAds(count: number | undefined): Promise<string[]> {
    try {
      const ads = await this.cacheManager.get<string[]>('ads');

      if (count === undefined || count > ads.length) {
        return ads;
      }

      return ads.slice(ads.length - count);
    } catch (error) {
      throw new AppError('Could not get ads from cache', error);
    }
  }

  private parseAdFromHtml(ad: string): string {
    try {
      return ad.substring(ad.indexOf('>') + 1, ad.lastIndexOf('<'));
    } catch (error) {
      throw new AppError('Could not parse ad from HTML.', error);
    }
  }

  private async storeAdInCache(ad: string): Promise<void> {
    try {
      let cachedAds =
        (await this.cacheManager.get<null | string[]>('ads')) ?? [];

      if (
        cachedAds.length === Number.parseInt(process.env.MAXIMUM_STORED_ADS)
      ) {
        cachedAds = cachedAds.slice(1);
      }

      const parsedAd = this.parseAdFromHtml(ad);
      cachedAds.push(parsedAd);

      await this.cacheManager.set('ads', cachedAds, 60);
    } catch (error) {
      throw new AppError('Could not store ad in cache.', error);
    }
  }
}
