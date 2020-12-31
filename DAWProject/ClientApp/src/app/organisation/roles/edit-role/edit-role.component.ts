import {Component, ElementRef, EventEmitter, Input, OnInit, Output, ViewChild, ViewContainerRef} from '@angular/core';
import {Role} from "../../models/Role";
import {RoleService} from "../role.service";

@Component({
  selector: 'app-edit-role',
  templateUrl: './edit-role.component.html',
  styleUrls: ['./edit-role.component.css']
})
export class EditRoleComponent implements OnInit {

  @Input() role: Role
  @Output() onSelectEdit: EventEmitter<any> = new EventEmitter();
  @Output() onEdit: EventEmitter<any> = new EventEmitter();
  @Output() onDelete: EventEmitter<any> = new EventEmitter();

  // @ts-ignore
  @ViewChild('closeBtn') closeButton: ElementRef;

  constructor(private roleService: RoleService) {
    this.role = new Role()
  }

  ngOnInit() {
  }


  onSelectEditClicked() {
    this.onSelectEdit.emit()
  }

  onSaveChanges() {
    this.roleService.updateRole(this.role).subscribe(_ => {
      this.closeButton.nativeElement.click()
      this.onEdit.emit()
    });
  }

  onSelectDelete() {
    this.roleService.deleteRole(this.role.id).subscribe(_ => {
      this.closeButton.nativeElement.click()
      this.onDelete.emit()
    })
  }
}
