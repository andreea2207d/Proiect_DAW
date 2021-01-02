import {Role} from "../organisation/models/Role";
import {Department} from "../organisation/models/Department";
import {Team} from "../engagement/models/Team";
import {Project} from "../engagement/models/Project";

export class User {
  id: string;
  firstName: string;
  lastName: string;
  username: string;
  role: Role;
  department: Department;
  team: Team;
  isTeamLeader: boolean
  projects: Array<Project>
}

export class UserCreation {
  id: string;
  firstName: string;
  lastName: string;
  username: string;
  password: string;
  role: Role;
  department: Department;
  team: Team;
  contractStartDate: Date;
  contractEndDate: Date;
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
  constructor(username?: string, password?: string) {
    this.username = username;
    this.password = password;
  }
}
