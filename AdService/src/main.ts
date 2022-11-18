import { NestFactory } from '@nestjs/core';
import { SwaggerModule, DocumentBuilder } from '@nestjs/swagger';
import { AppModule } from './app.module';

async function bootstrap() {
  const app = await NestFactory.create(AppModule);

  const config = new DocumentBuilder()
    .setTitle('Ads Service API')
    .setDescription(
      "This Ads Service API serves as a wrapper around Brian's Ads Service. It improves availability and speed with caching.",
    )
    .setVersion('1.0')
    .addTag('ads')
    .build();
  const document = SwaggerModule.createDocument(app, config);
  SwaggerModule.setup('/api', app, document);

  await app.listen(3000);
}
bootstrap();
