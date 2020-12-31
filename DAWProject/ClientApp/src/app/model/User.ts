import {Role} from "../organisation/models/Role";
import {Department} from "../organisation/models/Department";
import {Team} from "../engagement/models/Team";

export class User {
  id: string;
  firstName: string;
  lastName: string;
  username: string;
  role: Role;
  department: Department;
  team: Team;
}

export class UserSession {
  id: string;
  firstName: string;
  lastName: string;
  username: string;
  token: string;
}

export class UserLogin {
  username: string;
  password: string;
  constructor(username: string, password: string) {
    this.username = username;
    this.password = password;
  }
}
