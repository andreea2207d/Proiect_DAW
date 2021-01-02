import { Component, OnInit } from '@angular/core';
import {User} from "../../../model/User";
import {UserService} from "../../user.service";

@Component({
  selector: 'app-view-users',
  templateUrl: './view-users.component.html',
})
export class ViewUsersComponent implements OnInit {
  users: Array<User>;

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getAllUsers().subscribe(users => {
      this.users = users
    })
  }
}
