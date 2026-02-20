RESEARCH PROJECT:
------------------

"ASP.NET Core Web API .NET8 + (ReactJS + Typescript) PROJECT" : StockMarket Web App

BACK-END: C#, .NET Core Web API 8 (.NET 8)
FRONT-END: ReactJS + Typescript
DATABASE: MS-SQL in Docker container
AI tools as productivity accelerators: OpenAI Codex


COMPLETE PROJECT DEVELOPMENT & MANAGEMENT:
-------------------------------------------
1. Project developed in: C#, .NET WEB API 8, ReactJS, Typescript, MS-SQL, Docker
2. Add Test-Framework: XUnit
3. Create build packages in github
4. Deploy in github


AI Assisted Tasks for the Project Below:
---------------------------------------------
Unit Testing + CI/CD

1: Review & Stabilize API
------------------------------------
- Ensure controllers and services follow clean separation.
- Confirm dependency injection is properly structured.
- Refactor tightly coupled logic if needed.
 

2: Manually Design Testing Strategy (Before AI)
--------------------------------------------------
Define:
- What should be unit tested? (Services first)
- What should be integration tested?
- What dependencies need mocking?
- Expected coverage target (e.g., 70–80%)


3: Use Codex to Generate Unit Test Project
-------------------------------------------------
Tasks:
- Generate xUnit/NUnit test project
- Add Moq (or NSubstitute)
- Create test structure per service
- Generate sample test cases

Then:
- Review each generated test
- Improve assertions
- Remove weak tests
- Add edge cases manually

4: Add GitHub Actions CI Pipeline
----------------------------------------------
Use AI to scaffold:
- Restore
- Build
- Test
- Publish test results

Then:
- Manually review workflow
- Ensure failure conditions work
- Add badge to README

5: Add Code Coverage
-------------------------------------------------
- Integrate coverlet
- Fail build if coverage < threshold (optional)
- Document coverage metrics

   
