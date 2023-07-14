import { Directive, ElementRef, Input, OnInit, Renderer2 } from '@angular/core';
import { Md5 } from 'ts-md5/dist/md5';

@Directive({
  selector: '[appGravatar]'
})
export class GravatarDirective {

  @Input() set email(value: string) {
    this.updateGravatar(value);
  }

  constructor(private el: ElementRef, private renderer: Renderer2) { }

  updateGravatar(email: string): void {
    if (!email || !this.el.nativeElement) {
      return;
    }

    this.renderer.setAttribute(this.el.nativeElement, 'src', '//www.gravatar.com/avatar/' + Md5.hashStr(email.trim().toLowerCase()));
  }
}
