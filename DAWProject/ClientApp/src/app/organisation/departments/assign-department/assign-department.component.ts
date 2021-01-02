import { Component, OnInit } from '@angular/core';
import {UserService} from "../../user.service";
import {Router} from "@angular/router";
import {User} from "../../../model/User";
import {Department, DepartmentAssignment} from "../../models/Department";
import {DepartmentsService} from "../departments.service";

@Component({
  selector: 'app-assign-department',
  templateUrl: './assign-department.component.html',
  styleUrls: ['./assign-department.component.css']
})
export class AssignDepartmentComponent implements OnInit {

  users: Array<User>
  departments: Array<Department>
  selectedUser: User;
  selectedDepartment: Department;

  constructor(private userService: UserService, private departmentService: DepartmentsService,
              private router: Router) { }

  ngOnInit() {
    this.userService.getAllUsers().subscribe(result => {
      this.users = result
    })
    this.departmentService.getAllDepartments().subscribe(result => {
      this.departments = result
    })
  }

  selectDepartment(department: Department) {
    this.selectedDepartment = department
  }

  selectUser(user: User) {
    this.selectedUser = user
  }

  assignUserToDepartment() {
    let departmentAssignment = new DepartmentAssignment()
    departmentAssignment.userId = this.selectedUser.id
    departmentAssignment.departmentId = this.selectedDepartment.id
    this.departmentService.assignUser(departmentAssignment).subscribe(_ => {
      this.router.navigateByUrl('view-departments').then()
    })
  }
}
