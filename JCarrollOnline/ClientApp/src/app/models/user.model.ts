export class User {
  // Note: Using only optional constructor properties without backing store disables typescript's type checking for the type
  constructor(id?: string, userName?: string, fullName?: string, email?: string, roles?: string[], posts?: number, followers?: number, following?: number) {

    this.id = id;
    this.userName = userName;
    this.fullName = fullName;
    this.email = email;
    this.roles = roles;
    this.posts = posts;
    this.followers = followers;
    this.following = following;
  }

  get friendlyName(): string {
    let name = this.fullName || this.userName;

    return name;
  }


  public id: string;
  public userName: string;
  public fullName: string;
  public email: string;
  public isEnabled: boolean;
  public isLockedOut: boolean;
  public roles: string[];
  public posts: number;
  public followers: number;
  public following: number;
}
