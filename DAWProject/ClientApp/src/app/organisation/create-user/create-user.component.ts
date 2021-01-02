import { Component, OnInit } from '@angular/core';
import {UserCreation} from "../../model/User";
import {Router} from "@angular/router";
import {UserService} from "../user.service";

@Component({
  selector: 'app-create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {
  user: UserCreation;

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit() {
    this.user = new UserCreation()
  }

  onCreate() {
    this.userService.createUser(this.user).subscribe(_ => {
      this.router.navigateByUrl('/').then();
    })
  }
}
