import { ServicesService } from './services/services.service';
import { WorkDayPipe } from './components/work-days/work-day-description.pipe';
import { WorkDaysService } from './services/work-days.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './components/root/app.component';
import { WorkDaysPickerComponent } from './components/work-days/work-days-picker/work-days-picker.component';
import { HttpModule } from "@angular/http";
import { ServicesPickerComponent } from './components/services/services-picker/services-picker.component';

@NgModule({
  declarations: [
    AppComponent,
    WorkDaysPickerComponent,
    WorkDayPipe,
    ServicesPickerComponent
  ],
  imports: [
    BrowserModule,
    HttpModule
  ],
  providers: [
    WorkDaysService,
    ServicesService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }