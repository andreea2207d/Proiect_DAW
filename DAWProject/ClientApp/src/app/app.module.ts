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
import {CreateRoleComponent} from "./organisation/roles/create-role/create-role.component";
import {ViewProjectsComponent} from "./engagement/projects/view-projects/view-projects.component";
import {CreateProjectComponent} from "./engagement/projects/create-project/create-project.component";
import {ViewTeamsComponent} from "./engagement/teams/view-teams/view-teams.component";
import {CreateTeamComponent} from "./engagement/teams/create-team/create-team.component";

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
      { path: 'create-role', component: CreateRoleComponent, pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'view-projects', component: ViewProjectsComponent, pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'create-project', component: CreateProjectComponent, pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'view-teams', component: ViewTeamsComponent, pathMatch: 'full', canActivate: [AuthGuard] },
      { path: 'create-team', component: CreateTeamComponent, pathMatch: 'full', canActivate: [AuthGuard] },
    ])
  ],
  providers: [AuthenticationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
