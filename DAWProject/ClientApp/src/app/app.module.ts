import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import {HomeComponent} from "./home/home.component";
import {LoginComponent} from "./organisation/login/login.component";
import {CreateDepartmentComponent} from "./organisation/departments/create-department/create-department.component";
import {ViewDepartmentsComponent} from "./organisation/departments/view-departments/view-departments.component";
import {AuthGuard} from "./organisation/auth.guard";
import {AuthenticationService} from "./organisation/authentication.service";
import {ViewRolesComponent} from "./organisation/roles/view-roles/view-roles.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'login', component: LoginComponent, pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'create-department', component: CreateDepartmentComponent, pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'view-departments', component: ViewDepartmentsComponent, pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'view-roles', component: ViewRolesComponent, pathMatch: 'full', canActivate: [AuthGuard] },
    ])
  ],
  providers: [AuthenticationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
