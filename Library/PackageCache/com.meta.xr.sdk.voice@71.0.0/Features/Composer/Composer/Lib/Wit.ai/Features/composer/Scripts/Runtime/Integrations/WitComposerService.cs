/*
 * Copyright (c) Meta Platforms, Inc. and affiliates.
 * All rights reserved.
 *
 * Licensed under the Oculus SDK License Agreement (the "License");
 * you may not use the Oculus SDK except in compliance with the License,
 * which is provided at the time of installation or download, or which
 * otherwise accompanies this software in either electronic or hard copy form.
 *
 * You may obtain a copy of the License at
 *
 * https://developer.oculus.com/licenses/oculussdk/
 *
 * Unless required by applicable law or agreed to in writing, the Oculus SDK
 * distributed under the License is distributed on an "AS IS" BASIS,
 * WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
 * See the License for the specific language governing permissions and
 * limitations under the License.
 */

using Meta.WitAi.Composer.Interfaces;

namespace Meta.WitAi.Composer.Integrations
{
    public class WitComposerService : ComposerService
    {
        // Generate request handler immediately
        private WitComposerRequestHandler _requestHandler;
        protected override IComposerRequestHandler GetRequestHandler() => _requestHandler;

        // Get required event parameters
        private readonly static string[] _requiredParams = new string[] { WitComposerConstants.ENDPOINT_COMPOSER_MESSAGE_PARAM_TYPE };
        protected override string[] GetRequiredEventParams() => _requiredParams;

        /// <summary>
        /// Generate request handler on enable
        /// </summary>
        protected override void OnEnable()
        {
            base.OnEnable();
            if (_requestHandler == null)
            {
                _requestHandler = new WitComposerRequestHandler(VoiceService.WitConfiguration);
            }
        }
    }
}
