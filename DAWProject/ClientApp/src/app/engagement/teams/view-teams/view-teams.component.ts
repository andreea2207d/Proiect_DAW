import { Component, OnInit } from '@angular/core';
import {Team} from "../../models/Team";
import {TeamService} from "../team.service";

@Component({
  selector: 'app-view-teams',
  templateUrl: './view-teams.component.html',
  styleUrls: ['./view-teams.component.css']
})
export class ViewTeamsComponent implements OnInit {
  teams: Array<Team>;
  selectedTeam: Team;

  constructor(private teamsService: TeamService) { }

  ngOnInit() {
    this.loadTeams()
  }

  onDeleteTeam(team: Team) {
    console.log('deleting team ', team)
    this.teamsService.deleteTeam(team.id).subscribe(_ => {
      this.loadTeams()
    })
  }

  onEditFinished() {
    this.loadTeams()
  }

  onSelectEdit(team: Team) {
    this.selectedTeam = team
  }

  loadTeams() {
    this.teamsService.getAllTeams().subscribe(teams => {
      this.teams = teams
    })
  }
}
