import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {LoginComponent} from './login/login.component';
import {FormsModule} from "@angular/forms";
import {ViewDepartmentsComponent} from './departments/view-departments/view-departments.component';
import {CreateDepartmentComponent} from './departments/create-department/create-department.component';
import {EditDepartmentComponent} from './departments/edit-department/edit-department.component';
import {RouterModule} from "@angular/router";
import {CreateRoleComponent} from "./roles/create-role/create-role.component";
import {EditRoleComponent} from "./roles/edit-role/edit-role.component";
import {ViewRolesComponent} from "./roles/view-roles/view-roles.component";
import {RoleService} from "./roles/role.service";
import {DepartmentsService} from "./departments/departments.service";
import { UsernameDirective } from './username.directive';
import { AssignDepartmentComponent } from './departments/assign-department/assign-department.component';
import {AssignRoleComponent} from "./roles/assign-role/assign-role.component";
import {ViewUsersComponent} from "./users/view-users/view-users.component";
import {CreateUserComponent} from "./users/create-user/create-user.component";
import { BooleanToWordPipe } from './boolean-to-word.pipe';
import { NullToWordPipe } from './null-to-word.pipe';

@NgModule({
  declarations: [LoginComponent, ViewDepartmentsComponent, CreateDepartmentComponent, EditDepartmentComponent, ViewRolesComponent, CreateRoleComponent, EditRoleComponent, CreateUserComponent, UsernameDirective, AssignDepartmentComponent, AssignRoleComponent, ViewUsersComponent, BooleanToWordPipe, NullToWordPipe],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ],
  providers: [RoleService, DepartmentsService],
    exports: [LoginComponent, ViewDepartmentsComponent, CreateDepartmentComponent, EditDepartmentComponent, ViewRolesComponent, CreateRoleComponent, EditRoleComponent, CreateUserComponent, UsernameDirective, AssignDepartmentComponent, AssignRoleComponent, ViewUsersComponent],
})
export class OrganisationModule {
}
