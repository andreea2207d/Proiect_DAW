import { Component, OnInit } from '@angular/core';
import {Department} from "../../models/Department";
import {DepartmentsService} from "../departments.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-create-department',
  templateUrl: './create-department.component.html',
  styleUrls: ['./create-department.component.css']
})
export class CreateDepartmentComponent implements OnInit {
  department: Department;

  constructor(private departmentService: DepartmentsService, private router: Router) { }

  ngOnInit() {
    this.department = new Department()
  }

  onCreate() {
    this.departmentService.createDepartment(this.department).subscribe(_ => {
      this.router.navigateByUrl('/departments')
    })
  }
}
