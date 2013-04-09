CREATE TABLE [dbo].[Log] ( 
  [ID] [int] IDENTITY (1, 1) NOT NULL , 
  [Date] [datetime] NOT NULL , 
  [Thread] [varchar] (255) NOT NULL , 
  [Level] [varchar] (20) NOT NULL , 
  [Logger] [varchar] (255) NOT NULL , 
  [Message] [varchar] (4000) NOT NULL 
) ON [PRIMARY]