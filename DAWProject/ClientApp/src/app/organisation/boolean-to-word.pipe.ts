import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'booleanToWord'
})
export class BooleanToWordPipe implements PipeTransform {

  transform(value: any, ...args: any[]): any {
    return value ? 'Yes' : 'No';
  }

}
