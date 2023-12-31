﻿namespace StoneChallengeConsumptionApi.Domain.Interfaces;
public interface ITimeStamped
{
    DateTime CreatedAt { get; set; }
    DateTime? LastModifiedAt { get; set; }
}