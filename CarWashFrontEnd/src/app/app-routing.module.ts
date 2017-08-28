import { ReservationsComponent } from './components/reservations/reservations.component';
import { ServicesPickerComponent } from './components/services/services-picker/services-picker.component';
import { NgModule } from '@angular/core';
import { Router, Routes, RouterModule } from '@angular/router';

const routes: Routes = [

    { path: '', component: ReservationsComponent }

];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }