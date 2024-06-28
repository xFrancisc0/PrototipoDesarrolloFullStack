import 'dotenv/config';
import { bootstrapApplication } from '@angular/platform-browser';
import { appConfig } from './app/Base/app.config';
import { AppComponent } from './app/Base/app.component';

bootstrapApplication(AppComponent, appConfig)
  .catch((err) => console.error(err));
