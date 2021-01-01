import { Injectable } from '@angular/core';
import {Team, TeamAssignment} from "../models/Team";
import {BaseService} from "../../organisation/BaseService";


@Injectable({
  providedIn: 'root'
})
export class TeamService extends BaseService {

  getAllTeams() {
    return this.http.get<Array<Team>>(`${this.baseUrl}api/teams`)
  }

  createTeam(team: Team) {
    return this.http.post(`${this.baseUrl}api/teams`, team)
  }

  editTeam(team: Team) {
    return this.http.put(`${this.baseUrl}api/teams`, team)
  }

  deleteTeam(teamId: string) {
    return this.http.delete(`${this.baseUrl}api/teams/${teamId}`)
  }

  assignUser(teamAssignment: TeamAssignment) {
    return this.http.post(`${this.baseUrl}api/teams/assign/user`, teamAssignment)
  }

  assignTeamLead(teamAssignment: TeamAssignment) {
    return this.http.post(`${this.baseUrl}api/teams/assign/teamleader`, teamAssignment)
  }
}
