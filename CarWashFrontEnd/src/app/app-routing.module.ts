import { RegisterComponent } from './components/register/register.component';
import { SelectDateComponent } from './components/select-date/select-date.component';
import { AppComponent } from './components/root/app.component';
import { ReservationsComponent } from './components/reservations/reservations.component';
import { ServicesPickerComponent } from './components/services/services-picker/services-picker.component';
import { NgModule } from '@angular/core';
import { Router, Routes, RouterModule } from '@angular/router';

const routes: Routes = [

    { path: 'register', component: RegisterComponent },
    { path: 'select-date', component: SelectDateComponent },
    { path: 'confirmation', component: ReservationsComponent },
    { path: '', component: ServicesPickerComponent }

];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }