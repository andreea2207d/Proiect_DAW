import {User} from "../../model/User";


export class Team {
  id: string;
  name: string;
  teamLeader: User;
  employees: Array<User>;
}

export class TeamAssignment {
  userId: string;
  teamId: string;
}
