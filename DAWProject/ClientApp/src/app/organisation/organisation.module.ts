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

@NgModule({
  declarations: [LoginComponent, ViewDepartmentsComponent, CreateDepartmentComponent, EditDepartmentComponent, ViewRolesComponent, CreateRoleComponent, EditRoleComponent],
  imports: [
    CommonModule,
    FormsModule,
    RouterModule
  ],
  providers: [RoleService, DepartmentsService],
  exports: [LoginComponent, ViewDepartmentsComponent, CreateDepartmentComponent, EditDepartmentComponent, ViewRolesComponent, CreateRoleComponent, EditRoleComponent],
})
export class OrganisationModule {
}
