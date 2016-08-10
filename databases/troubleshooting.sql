-- add the extension we need for PostgreSQL
CREATE extension pg_stat_statements;

-- make sure its installed and ready
select * from pg_stat_statements;

-- find out where your config file is
show config_file;

-- after you've reset your config file for this extension
-- let the stats pile up for a few days
-- run the analysis query to see your biggest hits
select
  (total_time / 1000 / 60) as total_minutes,
  (total_time/calls) as average_time,
  query
from pg_stat_statements
where query not like '%pgbench%'
and query not like '%begin%'
and query not like '%end%'
order by 1 desc
limit 10;

-- you can grab the data for this from StackOverflow data dump
-- or you can load up the scifi.sql.zip file in the downloads for the book
-- once the db is loaded you can run a few queries to load up pg_stats

-- and index creation
create index concurrently idx_posts_view_count on posts(view_count);
create index concurrently idx_post_type_score on posts(post_type_id)
where score > 100;



