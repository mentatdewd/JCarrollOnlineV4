"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.User = void 0;
var User = /** @class */ (function () {
    // Note: Using only optional constructor properties without backing store disables typescript's type checking for the type
    function User(id, userName, fullName, email, roles, posts, followers, following) {
        this.id = id;
        this.userName = userName;
        this.fullName = fullName;
        this.email = email;
        this.roles = roles;
        this.posts = posts;
        this.followers = followers;
        this.following = following;
    }
    Object.defineProperty(User.prototype, "friendlyName", {
        get: function () {
            var name = this.fullName || this.userName;
            return name;
        },
        enumerable: false,
        configurable: true
    });
    return User;
}());
exports.User = User;
