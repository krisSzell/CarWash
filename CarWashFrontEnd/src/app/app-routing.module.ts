import { WorkDaysPickerComponent } from './components/work-days/work-days-picker/work-days-picker.component';
import { ReservationsComponent } from './components/reservations/reservations.component';
import { ServicesPickerComponent } from './components/services/services-picker/services-picker.component';
import { NgModule } from '@angular/core';
import { Router, Routes, RouterModule } from '@angular/router';

const routes: Routes = [

    { path: 'pick-date', component: WorkDaysPickerComponent },
    { path: '', component: ReservationsComponent }

];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }