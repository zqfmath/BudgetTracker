import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import {HomeComponent} from "./home/home.component";
import {UsersComponent} from "./users/users.component";
import {IncomesComponent} from "./incomes/incomes.component";
import {ExpendituresComponent} from "./expenditures/expenditures.component";



const routes: Routes = [
{
  path:"",
  component: HomeComponent
},

{
  path:"user",
  component: UsersComponent
},
{
  path:"income",
  component: IncomesComponent
},{
  path:"expenditure",
  component: ExpendituresComponent
}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
