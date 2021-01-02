import {Component, OnInit} from '@angular/core';
import {AuthenticationService} from "../organisation/authentication.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css']
})
export class NavMenuComponent implements OnInit {

  constructor(private authenticationService: AuthenticationService, private router: Router) {
  }

  ngOnInit(): void {
    this.authenticationService.userSubject.subscribe(user => {
      this.username = user ? user.username: '';
    })
  }

  isExpanded = false;
  username = '';

  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
    this.authenticationService.logout().subscribe(logout => {
      if(!logout) {
        this.router.navigateByUrl("login")
      }
    })
  }

  isUserLoggedIn() {
    return this.authenticationService.isUserLoggedIn()
  }
}
