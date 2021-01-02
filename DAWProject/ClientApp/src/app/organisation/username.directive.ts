import {Directive, ElementRef} from '@angular/core';

@Directive({
  selector: '[appUsername]'
})
export class UsernameDirective {

  constructor(el: ElementRef) {
    el.nativeElement.style.fontStyle = 'italic';
  }

}
