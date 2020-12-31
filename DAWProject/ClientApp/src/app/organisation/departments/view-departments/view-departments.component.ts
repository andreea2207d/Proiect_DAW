import { Component, OnInit } from '@angular/core';
import {Department} from "../../models/Department";
import {DepartmentsService} from "../departments.service";

@Component({
  selector: 'app-view-departments',
  templateUrl: './view-departments.component.html',
  styleUrls: ['./view-departments.component.css']
})
export class ViewDepartmentsComponent implements OnInit {
  departments: Array<Department>;
  selectedDepartment: Department;

  constructor(private departmentsService: DepartmentsService) { }

  ngOnInit() {
    this.departmentsService.getAllDepartments().subscribe(departments => {
      this.departments = departments
    })
  }

  onDeleteDepartment(department: Department) {
    this.departmentsService.deleteDepartment(department.id)
  }

  onEdit() {
    this.departmentsService.getAllDepartments().subscribe(departments => {
      this.departments = departments
    })
  }

  onSelectEdit(department: Department) {
    this.selectedDepartment = department
  }
}
