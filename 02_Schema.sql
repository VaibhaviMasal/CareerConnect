USE CareerConnectDb;
GO

-- =========================
-- USERS
-- =========================
CREATE TABLE Users (
    Id INT IDENTITY PRIMARY KEY,
    FullName NVARCHAR(100) NOT NULL,
    Email NVARCHAR(100) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role INT NOT NULL, -- 1=Candidate, 2=Recruiter, 3=Admin
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1
);
GO

-- =========================
-- CANDIDATE PROFILE
-- =========================
CREATE TABLE CandidateProfiles (
    Id INT IDENTITY PRIMARY KEY,
    UserId INT UNIQUE,
    PhoneNumber NVARCHAR(15),
    Location NVARCHAR(100),
    ExperienceYears INT DEFAULT 0,
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);
GO

-- =========================
-- RECRUITER PROFILE
-- =========================
CREATE TABLE RecruiterProfiles (
    Id INT IDENTITY PRIMARY KEY,
    UserId INT UNIQUE,
    CompanyName NVARCHAR(150),
    CompanyWebsite NVARCHAR(200),
    FOREIGN KEY (UserId) REFERENCES Users(Id)
);
GO

-- =========================
-- SKILLS
-- =========================
CREATE TABLE Skills (
    Id INT IDENTITY PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL
);
GO

-- =========================
-- JOB POSTINGS
-- =========================
CREATE TABLE JobPostings (
    Id INT IDENTITY PRIMARY KEY,
    RecruiterId INT NOT NULL,
    Title NVARCHAR(150),
    Description NVARCHAR(MAX),
    Location NVARCHAR(100),
    MinExperience INT,
    MaxExperience INT,
    CreatedAt DATETIME DEFAULT GETDATE(),
    IsActive BIT DEFAULT 1,
    FOREIGN KEY (RecruiterId) REFERENCES RecruiterProfiles(Id)
);
GO

-- =========================
-- JOB POSTING SKILLS (M-M)
-- =========================
CREATE TABLE JobPostingSkills (
    JobPostingId INT,
    SkillId INT,
    PRIMARY KEY (JobPostingId, SkillId),
    FOREIGN KEY (JobPostingId) REFERENCES JobPostings(Id),
    FOREIGN KEY (SkillId) REFERENCES Skills(Id)
);
GO

-- =========================
-- RESUMES
-- =========================
CREATE TABLE Resumes (
    Id INT IDENTITY PRIMARY KEY,
    CandidateId INT,
    FilePath NVARCHAR(255),
    IsCurrent BIT DEFAULT 1,
    UploadedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CandidateId) REFERENCES CandidateProfiles(Id)
);
GO

-- =========================
-- APPLICATIONS
-- =========================
CREATE TABLE Applications (
    Id INT IDENTITY PRIMARY KEY,
    CandidateId INT NOT NULL,
    JobPostingId INT NOT NULL,
    ResumeId INT NOT NULL,
    Status INT NOT NULL, -- 1=Applied, 2=Shortlisted, etc.
    AppliedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (CandidateId) REFERENCES CandidateProfiles(Id),
    FOREIGN KEY (JobPostingId) REFERENCES JobPostings(Id),
    FOREIGN KEY (ResumeId) REFERENCES Resumes(Id)
);
GO

-- =========================
-- INTERVIEW SCHEDULE
-- =========================
CREATE TABLE InterviewSchedules (
    Id INT IDENTITY PRIMARY KEY,
    ApplicationId INT,
    ScheduledAt DATETIME,
    Mode INT, -- 1=Online, 2=Offline
    Location NVARCHAR(200),
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ApplicationId) REFERENCES Applications(Id)
);
GO

-- =========================
-- CANDIDATE SKILLS (M-M)
-- =========================
CREATE TABLE CandidateSkills (
    CandidateProfileId INT,
    SkillId INT,
    PRIMARY KEY (CandidateProfileId, SkillId),
    FOREIGN KEY (CandidateProfileId) REFERENCES CandidateProfiles(Id),
    FOREIGN KEY (SkillId) REFERENCES Skills(Id)
);
GO

-- =========================
-- REFRESH TOKENS
-- =========================
CREATE TABLE RefreshTokens (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    UserId INT NOT NULL,
    Token NVARCHAR(500) NOT NULL,
    ExpiresAt DATETIME NOT NULL,
    CreatedAt DATETIME NOT NULL DEFAULT GETDATE(),
    RevokedAt DATETIME NULL,

    CONSTRAINT FK_RefreshTokens_Users
        FOREIGN KEY (UserId)
        REFERENCES Users(Id)
        ON DELETE CASCADE,

    CONSTRAINT UQ_RefreshTokens_Token
        UNIQUE (Token)
);
GO

CREATE INDEX IX_RefreshTokens_UserId
ON RefreshTokens(UserId);
GO