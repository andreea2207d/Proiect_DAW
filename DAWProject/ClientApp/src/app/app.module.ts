import {BrowserModule} from '@angular/platform-browser';
import {NgModule} from '@angular/core';
import {FormsModule} from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import {RouterModule} from '@angular/router';

import {AppComponent} from './app.component';
import {NavMenuComponent} from './nav-menu/nav-menu.component';
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
import {OrganisationModule} from "./organisation/organisation.module";
import {EngagementModule} from "./engagement/engagement.module";
import {CreateUserComponent} from "./organisation/users/create-user/create-user.component";
import {AssignDepartmentComponent} from "./organisation/departments/assign-department/assign-department.component";
import {AssignRoleComponent} from "./organisation/roles/assign-role/assign-role.component";
import {AssignProjectComponent} from "./engagement/projects/assign-project/assign-project.component";
import {AssignTeamComponent} from "./engagement/teams/assign-team/assign-team.component";
import {ViewUsersComponent} from "./organisation/users/view-users/view-users.component";

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent
  ],
  imports: [
    BrowserModule.withServerTransition({appId: 'ng-cli-universal'}),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      {path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuard]},
      {path: 'login', component: LoginComponent, pathMatch: 'full'},
      {path: 'create-department', component: CreateDepartmentComponent, pathMatch: 'full', canActivate: [AuthGuard]},
      {path: 'view-departments', component: ViewDepartmentsComponent, pathMatch: 'full', canActivate: [AuthGuard]},
      {path: 'view-roles', component: ViewRolesComponent, pathMatch: 'full', canActivate: [AuthGuard]},
      {path: 'create-role', component: CreateRoleComponent, pathMatch: 'full', canActivate: [AuthGuard]},
      {path: 'view-projects', component: ViewProjectsComponent, pathMatch: 'full', canActivate: [AuthGuard]},
      {path: 'create-project', component: CreateProjectComponent, pathMatch: 'full', canActivate: [AuthGuard]},
      {path: 'view-teams', component: ViewTeamsComponent, pathMatch: 'full', canActivate: [AuthGuard]},
      {path: 'create-team', component: CreateTeamComponent, pathMatch: 'full', canActivate: [AuthGuard]},
      {path: 'create-user', component: CreateUserComponent, pathMatch: 'full', canActivate: [AuthGuard]},
      {path: 'assign-department', component: AssignDepartmentComponent, pathMatch: 'full', canActivate: [AuthGuard]},
      {path: 'assign-role', component: AssignRoleComponent, pathMatch: 'full', canActivate: [AuthGuard]},
      {path: 'assign-project', component: AssignProjectComponent, pathMatch: 'full', canActivate: [AuthGuard]},
      {path: 'assign-team', component: AssignTeamComponent, pathMatch: 'full', canActivate: [AuthGuard]},
      {path: 'view-users', component: ViewUsersComponent, pathMatch: 'full', canActivate: [AuthGuard]},
    ]),
    OrganisationModule,
    EngagementModule
  ],
  providers: [AuthenticationService],
  bootstrap: [AppComponent]
})
export class AppModule {
}
