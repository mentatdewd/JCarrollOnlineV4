"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
exports.ItemModel = exports.ChannelModel = exports.FeedModel = exports.RSSModel = void 0;
var RSSModel = /** @class */ (function () {
    function RSSModel() {
        this.feed = new FeedModel();
    }
    return RSSModel;
}());
exports.RSSModel = RSSModel;
var FeedModel = /** @class */ (function () {
    function FeedModel() {
    }
    return FeedModel;
}());
exports.FeedModel = FeedModel;
var ChannelModel = /** @class */ (function () {
    function ChannelModel() {
        this.item = new Array();
    }
    return ChannelModel;
}());
exports.ChannelModel = ChannelModel;
var ItemModel = /** @class */ (function () {
    function ItemModel() {
    }
    return ItemModel;
}());
exports.ItemModel = ItemModel;
//export class EntryModel {
//  title: string;
//  content: ContentModel[] = new Array();
//  link: LinkModel[] = new Array();
//}
//export class ContentModel {
//  _: any;
//}
//export class LinkModel {
//  $: DollerModel[] = new Array();
//}
//export class DollerModel {
//  href: string;
//}
