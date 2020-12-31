import {Inject, Injectable} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {User, UserLogin, UserSession} from "../model/User";
import {map} from "rxjs/operators";
import {BaseService} from "./BaseService";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService extends BaseService {

  getUserSession(): UserSession {
    return JSON.parse(localStorage.getItem('currentUser'))
  }

  isUserLoggedIn() {
    return !this.getUserSession()
  }

  login(userLogin: UserLogin) {
    return this.http.post<UserSession>(`${this.baseUrl}api/users/authentificate`, userLogin)
      .pipe(map(user => {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        localStorage.setItem('currentUser', JSON.stringify(user));
        return user;
      }));
  }

  logout() {
    // remove user from local storage to log user out
    localStorage.removeItem('currentUser');
  }
}
