import { Injectable } from '@angular/core';
import {Role} from "../models/Role";
import {BaseService} from "../BaseService";

@Injectable({
  providedIn: 'root'
})
export class RoleService extends BaseService {

  getAllRoles() {
    return this.http.get<Array<Role>>(`${this.baseUrl}api/roles`)
  }

  createRole(role: Role) {
    return this.http.post(`${this.baseUrl}api/roles`, role)
  }

  updateRole(role: Role) {
    return this.http.post(`${this.baseUrl}api/roles`, role)
  }

  deleteRole(id: any) {
    return this.http.delete(`${this.baseUrl}api/roles/${id}`)
  }
}
