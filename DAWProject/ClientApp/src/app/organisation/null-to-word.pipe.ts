import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'nullToWord'
})
export class NullToWordPipe implements PipeTransform {

  transform(value: any, ...args: any[]): any {
    return value != null ? value : 'n/a';
  }
}
