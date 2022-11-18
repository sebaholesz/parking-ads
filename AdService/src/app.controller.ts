import {
  Controller,
  Get,
  HttpException,
  HttpStatus,
  Query,
  Res,
} from '@nestjs/common';
import { Response } from 'express';
import { AppService } from './app.service';

@Controller()
export class AppController {
  constructor(private readonly appService: AppService) {}

  @Get()
  async getAds(
    @Query('count') count,
    @Res() res: Response,
  ): Promise<Response<string[], Record<string, any>>> {
    if (typeof count !== 'string' && typeof count !== 'undefined') {
      throw new HttpException(
        'Invalid query parameter type.',
        HttpStatus.BAD_REQUEST,
      );
    }

    const parsedCountAsInt = Number.parseInt(count);

    if (!Number.isSafeInteger(parsedCountAsInt) && count !== undefined) {
      throw new HttpException(
        'Invalid query parameter value.',
        HttpStatus.BAD_REQUEST,
      );
    }

    try {
      const ads = await this.appService.getAds(parsedCountAsInt);

      return res.status(HttpStatus.OK).json(ads);
    } catch (error) {
      throw new HttpException(
        'Could not get ads.',
        HttpStatus.INTERNAL_SERVER_ERROR,
      );
    }
  }
}
