import { Injectable } from '@angular/core';
import {BaseService} from "./BaseService";
import {User, UserCreation} from "../model/User";

@Injectable({
  providedIn: 'root'
})
export class UserService extends BaseService {

  createUser(userCreationRequest: UserCreation) {
    return this.http.post(`${this.baseUrl}api/users/`, userCreationRequest)
  }

  getAllUsers() {
    return this.http.get<Array<User>>(`${this.baseUrl}api/users/`)
  }
}
