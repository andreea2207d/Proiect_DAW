import {Component, OnInit} from '@angular/core';
import {Role} from "../../models/Role";
import {RoleService} from "../role.service";

@Component({
  selector: 'app-view-roles',
  templateUrl: './view-roles.component.html',
  styleUrls: ['./view-roles.component.css']
})
export class ViewRolesComponent implements OnInit {
  roles: Array<Role>;
  selectedRole: Role;

  constructor(private roleService: RoleService) { }

  ngOnInit() {
    this.roleService.getAllRoles().subscribe(roles => {
      this.roles = roles
    })
  }

  onSelectRole(role: Role) {
    this.selectedRole = role
  }

  onEdited() {
    this.roleService.getAllRoles().subscribe(roles => {
      this.roles = roles
    })
  }

  onDeleted() {
    this.roleService.getAllRoles().subscribe(roles => {
      this.roles = roles
    })
  }

  onCreated() {
    this.roleService.getAllRoles().subscribe(roles => {
      this.roles = roles
    })
  }
}
