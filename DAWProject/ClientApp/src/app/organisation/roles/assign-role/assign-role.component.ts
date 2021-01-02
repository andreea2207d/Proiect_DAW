import { Component, OnInit } from '@angular/core';
import {UserService} from "../../user.service";
import {Router} from "@angular/router";
import {User} from "../../../model/User";
import {Role, RoleAssignment} from "../../models/Role";
import {RoleService} from "../role.service";

@Component({
  selector: 'app-assign-role',
  templateUrl: './assign-role.component.html',
  styleUrls: ['./assign-role.component.css']
})
export class AssignRoleComponent implements OnInit {

  users: Array<User>
  roles: Array<Role>
  selectedUser: User;
  selectedRole: Role;

  constructor(private userService: UserService, private roleService: RoleService,
              private router: Router) { }

  ngOnInit() {
    this.userService.getAllUsers().subscribe(result => {
      this.users = result
    })
    this.roleService.getAllRoles().subscribe(result => {
      this.roles = result
    })
  }

  selectRole(role: Role) {
    this.selectedRole = role
  }

  selectUser(user: User) {
    this.selectedUser = user
  }

  assignUserToRole() {
    let roleAssignment = new RoleAssignment()
    roleAssignment.userId = this.selectedUser.id
    roleAssignment.roleId = this.selectedRole.id
    this.roleService.assignUser(roleAssignment).subscribe(_ => {
      this.router.navigateByUrl('view-roles').then()
    })
  }
}
