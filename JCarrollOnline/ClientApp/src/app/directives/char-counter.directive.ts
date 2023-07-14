import {
  Directive,
  ElementRef,
  HostListener,
  Input,
  Renderer2
} from "@angular/core";

// This directive can only be used on an input with type text or a textarea element and requires a maxlength property.
@Directive({
  selector: "[characterCountContainer]"
})
export class CharacterCountDirective {
  @Input("characterCountContainer")
  countContainer: ElementRef;
  maxLength: number;

  constructor(private elementRef: ElementRef, private renderer: Renderer2) {
    const inputType = elementRef.nativeElement.getAttribute("type");
    const inputTag = elementRef.nativeElement.tagName;

    this.maxLength = elementRef.nativeElement.getAttribute("maxlength");

    const validElement =
      (this.maxLength && (inputTag === "INPUT" && inputType === "text")) ||
      inputTag === "TEXTAREA";

    if (!validElement) {
      throw new Error(
        "The CharacterCountDirective can only be used on an input type text or textarea element and requires a maxlength property"
      );
    }
  }

  @HostListener("keyup", ["$event"])
  setRemainingCharacterCount(event: any) {
    if (this.maxLength) {
      const remainingCount = this.maxLength - event.target.value.length;
      this.renderer.setProperty(
        this.countContainer,
        "innerHTML",
        `<label>Characters remaining ${remainingCount}</label>`
      );
    }
  }
}

// 1. this.maxLength AND
// 2. inputTag ==== "INPUT" and inputType === "text" OR
// 3. inputTag === "TEXTAREA"
