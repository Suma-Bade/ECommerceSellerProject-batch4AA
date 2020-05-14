import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SellerLandingPageComponent } from './Seller/seller-landing-page/seller-landing-page.component';
import { AddItemsComponent } from './Seller/add-items/add-items.component';
import { ViewItemsComponent } from './Seller/view-items/view-items.component';
import { ViewProfileComponent } from './Seller/view-profile/view-profile.component';
import { SellerRegisterComponent } from './Account/seller-register/seller-register.component';
import { LoginComponent } from './Account/login/login.component';
import { HomeComponent } from './home/home.component';


const routes: Routes = [
  {path:'SELLER',component:SellerLandingPageComponent,children:[
    {path:'ADD-ITEMS',component:AddItemsComponent},
    {path:'VIEW-ITEMS',component:ViewItemsComponent},
    {path:'VIEW-PROFILE',component:ViewProfileComponent}]},
    {path:'REGISTER-SELLER',component:SellerRegisterComponent},
    {path:'LOGIN',component:LoginComponent},
    {path:'HOME',component:HomeComponent},
  {path:'',redirectTo:'HOME',pathMatch:'full'}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
