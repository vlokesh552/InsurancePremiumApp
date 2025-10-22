import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UserPremiumCalculatorComponent } from './components/user-premium-calculator/user-premium-calculator.component';

const routes: Routes = [
  { path: '', redirectTo: 'userpremium', pathMatch: 'full' },
  { path: 'userpremium', component: UserPremiumCalculatorComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
