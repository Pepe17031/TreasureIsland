// SPDX-License-Identifier: MIT
pragma solidity ^0.8.16;

import {VRFConsumerBase} from "@bisonai/orakl-contracts/src/v0.1/VRFConsumerBase.sol";
import {IVRFCoordinator} from "@bisonai/orakl-contracts/src/v0.1/interfaces/IVRFCoordinator.sol";
import {IPrepayment} from "@bisonai/orakl-contracts/src/v0.1/interfaces/IPrepayment.sol";

contract VRFConsumer is VRFConsumerBase {
    uint256 public sRandomWord1;
	uint256 public sRandomWord2;
    uint256 public sRandomWord3;
	uint256 public sRandomWord000;

    IVRFCoordinator COORDINATOR;

    constructor() VRFConsumerBase(0xDA8c0A00A372503aa6EC80f9b29Cc97C454bE499) {
        COORDINATOR = IVRFCoordinator(0xDA8c0A00A372503aa6EC80f9b29Cc97C454bE499);
    }

    // Receive remaining payment from requestRandomWordsPayment
    receive() external payable {}

    function requestRoulete() public payable returns (uint256 requestId) {
		uint32 numWords = 4;
		bytes32 keyHash = 0xd9af33106d664a53cb9946df5cd81a30695f5b72224ee64e798b278af812779c;
		uint32 callbackGasLimit = 300000;
		address refundRecipient = msg.sender;
        uint64 bet = 500000000000000000;

        requestId = COORDINATOR.requestRandomWords{value: msg.value - bet}(
            keyHash,
            callbackGasLimit,
            numWords,
            refundRecipient
        );
    }

    function fulfillRandomWords(
        uint256 /* requestId */,
        uint256[] memory randomWords
    ) internal override {
        // requestId should be checked if it matches the expected request
        // Generate random value between 1 and 3.
        sRandomWord1 = (randomWords[0] % 3) + 1;
		sRandomWord2 = (randomWords[1] % 3) + 1;
        sRandomWord3 = (randomWords[2] % 3) + 1;
        sRandomWord000 = (randomWords[2] % 2) + 1;
    }

    function sendMoney(uint64 sum) public payable {
        address payable payableRecipient = payable(msg.sender);
        payableRecipient.transfer(sum);
    }
}