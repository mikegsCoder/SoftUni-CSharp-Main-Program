CREATE PROC usp_PlaceOrder
(@jobId         INT,
 @partSerialNum VARCHAR(50),
 @quantity      INT
)
AS
     BEGIN
	--check quantity
         IF(@quantity <= 0)
            BEGIN
                 RAISERROR('Part quantity must be more than zero!', 16, 1);
                 RETURN;
		  END;

	 --declare and check jobId
	    DECLARE @jobIdSelected INT=
         (
             SELECT JobId
             FROM Jobs
             WHERE JobId = @jobId
         );
         IF(@jobIdSelected IS NULL)
            BEGIN
                 RAISERROR('Job not found!', 16, 1);
                 RETURN;
		  END;

	  --declare and check job status
         DECLARE @JobStatus VARCHAR(11)=
         (
             SELECT Status
             FROM JOBS
             WHERE JobId = @jobId
         );
	             
         IF(@JobStatus = 'Finished')
            BEGIN
                 RAISERROR('This job is not active!', 16, 1);
                 RETURN;
		  END;

	   --declare and check serial number
         DECLARE @partId INT=
         (
             SELECT PartId
             FROM Parts
             WHERE SerialNumber = @partSerialNum
         );
         IF(@partId IS NULL)
            BEGIN
                 RAISERROR('Part not found!', 16, 1);
                 RETURN;
		  END;

	   -- check if order for partId exist
         DECLARE @OrderId INT=
         (
             SELECT o.OrderId
             FROM Orders o
             WHERE JobId = @jobId AND IssueDate IS NULL
	    )
	    --if order for part does not exist create new one
         IF(@OrderId IS NULL)
            BEGIN
                 INSERT INTO Orders(JobId, IssueDate)
                 VALUES (@jobId, NULL );

                 INSERT INTO OrderParts(OrderId,PartId,Quantity)
                 VALUES (IDENT_CURRENT('Orders'),@partId,@quantity);
		  END;
		--if order exist
         ELSE
          BEGIN
		   DECLARE @PartExistInOrder INT =(SELECT @@ROWCOUNT FROM OrderParts WHERE OrderId=@OrderId AND PartId=@partId)

		   IF  (@PartExistInOrder IS NULL)
		   BEGIN
				 -- if part not exist in order =>add part
				 INSERT INTO OrderParts(OrderId,PartId,Quantity)
				 VALUES (@OrderId,@partId,@quantity);
		   END
		   ELSE
		   BEGIN
				--if part exist add only quantity
				UPDATE OrderParts
				SET Quantity+=@quantity
				WHERE OrderId=@OrderId AND PartId=@partId
		   END
        END;
     END;