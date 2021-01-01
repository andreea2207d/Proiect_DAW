import { Component, OnInit } from '@angular/core';
import {Team} from "../../models/Team";
import {TeamService} from "../team.service";
import {Router} from "@angular/router";

@Component({
  selector: 'app-create-team',
  templateUrl: './create-team.component.html',
  styleUrls: ['./create-team.component.css']
})
export class CreateTeamComponent implements OnInit {
  team: Team;

  constructor(private teamService: TeamService, private router: Router) { }

  ngOnInit() {
    this.team = new Team()
  }

  onCreate() {
    this.teamService.createTeam(this.team).subscribe(_ => {
      this.router.navigateByUrl('/teams')
    })
  }
}
