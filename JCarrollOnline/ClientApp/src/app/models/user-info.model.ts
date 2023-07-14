export class UserInfoModel {
  constructor(id: string,
    userName: string,
    fullName: string,
    email: string,
    roles: string[],
    postCount: number,
    followersCount: number,
    followingCount: number) {
    this.id = id;
    this.userName = userName;
    this.fullName = fullName;
    this.email = email;
    this.roles = roles;
    this.postCount = postCount;
    this.followersCount = followersCount;
    this.followingCount = followingCount;
  }

  public id?: string;
  public userName?: string;
  public fullName?: string;
  public email?: string;
  public roles?: string[];
  public postCount: number;
  public followersCount: number;
  public followingCount: number;
  public isEnabled: boolean;
  public isLockedOut: boolean;
}
