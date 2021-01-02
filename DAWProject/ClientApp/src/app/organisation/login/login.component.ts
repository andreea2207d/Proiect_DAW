import { Component, OnInit } from '@angular/core';
import {UserLogin} from "../../model/User";
import {Router} from "@angular/router";
import {AuthenticationService} from "../authentication.service";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  user: UserLogin;

  constructor(private router: Router, private authenticationService: AuthenticationService) { }

  ngOnInit() {
    this.user = new UserLogin()
  }

  onLogin() {
    this.authenticationService.login(this.user)
      .subscribe(
        _ => {
          this.router.navigate(["/"]);
        });
  }
}
