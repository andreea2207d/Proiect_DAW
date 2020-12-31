import { Injectable } from '@angular/core';
import {BaseService} from "../BaseService";
import {Department, DepartmentAssignment} from "../models/Department";

@Injectable({
  providedIn: 'root'
})
export class DepartmentsService extends BaseService {

  getAllDepartments() {
    return this.http.get<Array<Department>>(`${this.baseUrl}api/departments`)
  }

  createDepartment(department: Department) {
    return this.http.post(`${this.baseUrl}api/departments`, department)
  }

  editDepartment(department: Department) {
    return this.http.put(`${this.baseUrl}api/departments`, department)
  }

  deleteDepartment(departmentId: string) {
    return this.http.delete(`${this.baseUrl}api/departments/${departmentId}`)
  }

  assignUser(departmentAssignment: DepartmentAssignment) {
    return this.http.post(`${this.baseUrl}api/departments/assign/user`, departmentAssignment)
  }

}
