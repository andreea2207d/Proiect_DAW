import { Component, OnInit } from '@angular/core';

import {Router} from "@angular/router";
import {User} from "../../../model/User";
import {Team, TeamAssignment} from "../../models/Team";
import {TeamService} from "../team.service";
import {UserService} from "../../../organisation/user.service";

@Component({
  selector: 'app-assign-Team',
  templateUrl: './assign-Team.component.html',
  styleUrls: ['./assign-Team.component.css']
})
export class AssignTeamComponent implements OnInit {

  users: Array<User>
  Teams: Array<Team>
  selectedUser: User;
  selectedTeam: Team;
  isUserTeamLead: boolean

  constructor(private userService: UserService, private teamService: TeamService,
              private router: Router) { }

  ngOnInit() {
    this.userService.getAllUsers().subscribe(result => {
      this.users = result
    })
    this.teamService.getAllTeams().subscribe(result => {
      this.Teams = result
    })
  }

  selectTeam(Team: Team) {
    this.selectedTeam = Team
  }

  selectUser(user: User) {
    this.selectedUser = user
  }

  assignUserToTeam() {
    let teamAssignment = new TeamAssignment()
    teamAssignment.userId = this.selectedUser.id
    teamAssignment.teamId = this.selectedTeam.id
    this.teamService.assignUser(teamAssignment).subscribe(_ => {
      this.router.navigateByUrl('view-teams').then()
    })

    if (this.isUserTeamLead) {
      this.teamService.assignTeamLead(teamAssignment).subscribe(_ => {
        this.router.navigateByUrl('view-teams').then()
      })
    }
  }
}
