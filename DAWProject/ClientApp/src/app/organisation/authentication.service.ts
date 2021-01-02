import {Injectable} from '@angular/core';
import {User, UserLogin, UserSession} from "../model/User";
import {map} from "rxjs/operators";
import {BaseService} from "./BaseService";
import {Observable, Subject} from "rxjs";

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService extends BaseService {

  public userSubject = new Subject<UserSession>()

  getUserSession(): UserSession {
    return JSON.parse(localStorage.getItem('currentUser'))
  }

  isUserLoggedIn() {
    return this.getUserSession() != null && this.getUserSession() != undefined
  }

  login(userLogin: UserLogin) {
    return this.http.post<UserSession>(`${this.baseUrl}api/users/authentificate`, userLogin)
      .pipe(map(user => {
        // store user details and jwt token in local storage to keep user logged in between page refreshes
        localStorage.setItem('currentUser', JSON.stringify(user));
        this.userSubject.next(user)
        return user;
      }));
  }

  logout() {
    // remove user from local storage to log user out
    return new Observable<any>(observer => {
      localStorage.removeItem('currentUser');
      this.userSubject.next(null)
      observer.next(this.isUserLoggedIn())
    });
  }
}
