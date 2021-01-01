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
    this.teamsService.getAllTeams().subscribe(teams => {
      this.teams = teams
    })
  }

  onDeleteTeam(team: Team) {
    this.teamsService.deleteTeam(team.id)
  }

  onEdit() {
    this.teamsService.getAllTeams().subscribe(teams => {
      this.teams = teams
    })
  }

  onSelectEdit(team: Team) {
    this.selectedTeam = team
  }
}
