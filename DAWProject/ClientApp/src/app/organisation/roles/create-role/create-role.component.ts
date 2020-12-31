import {Component, ElementRef, EventEmitter, OnInit, Output, ViewChild} from '@angular/core';
import {Role} from "../../models/Role";
import {RoleService} from "../role.service";

@Component({
  selector: 'app-create-role',
  templateUrl: './create-role.component.html',
  styleUrls: ['./create-role.component.css']
})
export class CreateRoleComponent implements OnInit {

  role: Role

  // @ts-ignore
  @ViewChild("closeButton") closeButton: ElementRef;
  @Output() onCreate: EventEmitter<any> = new EventEmitter();

  constructor(private roleService: RoleService) { }

  ngOnInit() {
    this.role = new Role()
  }

  onCreateSelected() {
    this.roleService.createRole(this.role).subscribe(_ => {
      this.closeButton.nativeElement.click()
      this.onCreate.emit()
    })
  }
}
