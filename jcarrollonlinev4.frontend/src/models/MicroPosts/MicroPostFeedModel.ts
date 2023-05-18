import { MicropostFeedItemModel } from "./MicroPostFeedItemModel";
import { MicropostModelBase } from "./MicroPostModelBase";

export interface MicropostFeedModel extends MicropostModelBase {
  MicroPostFeedItems: MicropostFeedItemModel[];
  OnePageOfMicroPosts: MicropostFeedItemModel[];
}
